    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.IO;
    static class Program
    {
        static void Main()
        {
            var path = "big.blob";
            WriteFile(path);
            
            int channelTotal = 0, pointTotal = 0;
            foreach(var channel in ReadChannels(path))
            {
                channelTotal++;
                pointTotal += channel.Points.Count;
            }
            Console.WriteLine("Read: {0} points in {1} channels", pointTotal, channelTotal);
        }
        private static void WriteFile(string path)
        {
            string[] channels = {"up", "down", "top", "bottom", "charm", "strange"};
            var rand = new Random(123456);
    
            int totalPoints = 0, totalChannels = 0;
            using (var encoder = new DataEncoder(path, "My file"))
            {
                for (int i = 0; i < 100; i++)
                {
                    var channel = new Channel {
                        Name = channels[rand.Next(channels.Length)]
                    };
                    int count = rand.Next(1, 50);
                    var data = new List<float>(count);
                    for (int j = 0; j < count; j++)
                        data.Add((float)rand.NextDouble());
                    channel.Points = data;
                    encoder.AddChannel(channel);
                    totalPoints += count;
                    totalChannels++;
                }
            }
    
            Console.WriteLine("Wrote: {0} points in {1} channels; {2} bytes", totalPoints, totalChannels, new FileInfo(path).Length);
        }
        public class Channel
        {
            public string Name { get; set; }
            public List<float> Points { get; set; }
        }
        public class DataEncoder : IDisposable
        {
            private Stream stream;
            private ProtoWriter writer;
            public DataEncoder(string path, string recordingName)
            {
                stream = File.Create(path);
                writer = new ProtoWriter(stream, null, null);
    
                if (recordingName != null)
                {
                    ProtoWriter.WriteFieldHeader(1, WireType.String, writer);
                    ProtoWriter.WriteString(recordingName, writer);
                }
            }
            public void AddChannel(Channel channel)
            {
                ProtoWriter.WriteFieldHeader(2, WireType.StartGroup, writer);
                var channelTok = ProtoWriter.StartSubItem(null, writer);
    
                if (channel.Name != null)
                {
                    ProtoWriter.WriteFieldHeader(1, WireType.String, writer);
                    ProtoWriter.WriteString(channel.Name, writer);
                }
                var list = channel.Points;
                if (list != null)
                {
                    
                    switch(list.Count)
                    {
                        case 0:
                            // nothing to write
                            break;
                        case 1:
                            ProtoWriter.WriteFieldHeader(2, WireType.Fixed32, writer);
                            ProtoWriter.WriteSingle(list[0], writer);
                            break;
                        default:
                            ProtoWriter.WriteFieldHeader(2, WireType.String, writer);
                            var dataToken = ProtoWriter.StartSubItem(null, writer);
                            ProtoWriter.SetPackedField(2, writer);
                            foreach (var val in list)
                            {
                                ProtoWriter.WriteFieldHeader(2, WireType.Fixed32, writer);
                                ProtoWriter.WriteSingle(val, writer);
                            }
                            ProtoWriter.EndSubItem(dataToken, writer);
                            break;
                    }
                }
                ProtoWriter.EndSubItem(channelTok, writer);
            }
            public void Dispose()
            {
                using (writer) { if (writer != null) writer.Close(); }
                writer = null;
                using (stream) { if (stream != null) stream.Close(); }
                stream = null;
            }
        }
    
        private static IEnumerable<Channel> ReadChannels(string path)
        {
            using (var file = File.OpenRead(path))
            using (var reader = new ProtoReader(file, null, null))
            {
                while (reader.ReadFieldHeader() > 0)
                {
                    switch (reader.FieldNumber)
                    {
                        case 1:
                            Console.WriteLine("Recording name: {0}", reader.ReadString());
                            break;
                        case 2: // each "2" instance represents a different "Channel" or a channel switch
                            var channelToken = ProtoReader.StartSubItem(reader);
                            int floatCount = 0;
                            List<float> list = new List<float>();
                            Channel channel = new Channel { Points = list };
                            while (reader.ReadFieldHeader() > 0)
                            {
                                
                                switch (reader.FieldNumber)
                                {
                                    case 1:
                                        channel.Name = reader.ReadString();
                                        break;
                                    case 2:
                                        switch (reader.WireType)
                                        {
                                            case WireType.String: // packed array - multiple floats
                                                var dataToken = ProtoReader.StartSubItem(reader);
                                                while (ProtoReader.HasSubValue(WireType.Fixed32, reader))
                                                {
                                                    list.Add(reader.ReadSingle());
                                                    floatCount++;
                                                }
                                                ProtoReader.EndSubItem(dataToken, reader);
                                                break;
                                            case WireType.Fixed32: // simple float
                                                list.Add(reader.ReadSingle());
                                                floatCount++; // got 1
                                                break;
                                            default:
                                                Console.WriteLine("Unexpected data wire-type: {0}", reader.WireType);
                                                break;
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Unexpected field in channel: {0}/{1}", reader.FieldNumber, reader.WireType);
                                        reader.SkipField();
                                        break;
                                }
                            }
                            ProtoReader.EndSubItem(channelToken, reader);
                            yield return channel;
                            break;
                        default:
                            Console.WriteLine("Unexpected field in recording: {0}/{1}", reader.FieldNumber, reader.WireType);
                            reader.SkipField();
                            break;
                    }
                }
            }
        }
    }
