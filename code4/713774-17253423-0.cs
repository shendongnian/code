    namespace PrototypeAP
    {
    static class PWM
    {
 
        static string fifoName = "/dev/pi-blaster";
        static FileStream file;
        static StreamWriter write;
        static PWM()
        {
            file = new FileInfo(fifoName).OpenWrite();
            write = new StreamWriter(file, Encoding.ASCII);
        }
        //FIRST METHOD
        public static void Set(int channel, float value)
        {
            string s = channel + "=" + value + "\n";
            Console.WriteLine(s);
            write.Write(s);
            write.Flush();
        }
    }
    }
