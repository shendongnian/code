    static void Main(string[] args)
        {
            try
            {
                SPSite site = new SPSite("http://xxx");
                foreach (SPWeb web in site.AllWebs)
                {
                    Console.WriteLine(web.Title);
                    foreach (SPList list in web.Lists)
                        Console.WriteLine("List: " + list.Title);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("End");
            Console.Read();            
        }       
