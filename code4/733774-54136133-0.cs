            Subject subject = new Subject();
            XmlSerializer serializer = new XmlSerializer(typeof(Subject));
            using (Stream stream = new MemoryStream())
            {
                serializer.Serialize(stream, subject);
                // do something with stream
                Subject subject2 = (Subject)serializer.Deserialize(stream);
                // do something with subject2
            }
