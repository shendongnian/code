            while (rf.Peek() >= 0)
            {
                line = rf.ReadLine().Trim();
                MessageBox.Show(line.Length.ToString());
                // test
                string x = "abc";
                string y = x.Substring(0, 20);
                // end test
                if (line.Substring(0, 57) == "<td align=\"right\" nowrap=\"nowrap\"><span       class=\"currency\">")
                {
                    break;
                }
                // some more code 
            }
