    string str = "<html> <head><style type='text/css'> jhiun  </style></head> </html>";
                Console.WriteLine(str);
                string strToRemove = str.Substring(str.IndexOf("<style"), str.IndexOf("</style>") - str.IndexOf("<style") + 8); 
                Console.WriteLine(str.Replace(strToRemove,""));
                Console.ReadLine();
