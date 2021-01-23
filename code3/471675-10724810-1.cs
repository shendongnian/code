        public static string Read(this string message)
        {
            //do something
            return message;
        }
        public static string Write(this string message)
        {
            //do something
            return message;
        }
        public static void Method()
        {
            "message".Read().Write();
            "message".Write().Read(); // this is problem!
        }
