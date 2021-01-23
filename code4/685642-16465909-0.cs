            string pathname = Server.MapPath("/");
            int counter = 1;
            string file = String.Empty;
            List<string> list = new List<string>();
            //Add the list items
            for (int i = 0; i <= 1234; i++)
            {
                list.Add(String.Format("item {0}", i));
            }
            //write to file
            for (int i = 1; i < list.Count(); i++)
            {
                //generate a dynamic filename with path
                file = String.Format("{0}Seed{1}.txt", pathname, counter);
                //the using statement closes the streamwriter when it completes the process
                using (StreamWriter text = new StreamWriter(file, true))
                {
                    //write the line
                    text.Write(list[i]);
                }
                //check to see if the max lines have been written
                if (i == counter * 100) counter++;                
            }
