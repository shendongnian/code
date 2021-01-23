    class string_builder
    {
        string previousvalue = null;
        StringBuilder sB;
        public string_builder()
        {
            sB = new StringBuilder();
        }
        public void AppendToStringBuilder(string new_val)
        {
            if (previousvalue.EndsWith("\n") &&  !String.IsNullOrEmpty(previousvalue) )
            {
                sB.Append(new_val);
            }
            else
            {
                sB.AppendLine(new_val);
            }
            previousvalue = new_val;
        }
    }
    class Program
    {
        
        public static void Main(string[] args)
        {
            string_builder sb = new string_builder();            
            sb.AppendToStringBuilder("this is line1\n");
            sb.AppendToStringBuilder("this is line2");
            sb.AppendToStringBuilder("\nthis is line3\n");
        }            
    }
