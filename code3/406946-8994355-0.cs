    public static class Helper
    {
        public static void ToEntity(this MeetingDto source)
        {
            Console.WriteLine ("MeetingDto.ToEntity");
            //Do Stuff
            (source as IDocumentDto).ToEntity();
        }
        
        public static void ToEntity(this ContactDto source)
        {
            Console.WriteLine ("ContactDto.ToEntity");
            //Do Stuff
            (source as IBaseDto).ToEntity();
        }
        
        public static void ToEntity(this IDocumentDto source)
        {
            Console.WriteLine ("IDocumentDto.ToEntity");
            //Do Stuff
            foreach (var element in source.Subscriptions)
            {
                element.ToEntity();
            }
        }
        
        public static void ToEntity(this IBaseDto source)
        {
            Console.WriteLine ("IBaseDto.ToEntity");
            //Do Stuff        
        }
    }
