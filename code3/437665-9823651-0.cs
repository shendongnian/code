        public enum JuiceTypes
        {
            Apple,
            Orange,
            Pineapple,
            Peach,
            HoneyTea,
            Tomato
        }
            string[] juiceTypes = Enum.GetNames(typeof(JuiceTypes));
            foreach (string juice in juiceTypes)
            {
                Console.WriteLine(juice); 
                //in MVC you need to use Response.WriteLine("<input type=\"radio\" value=\"+juice+"\"/>");
            }
