    bool result = Regex.IsMatch("\\bthe\\b", text);
    (using System.Text.RegularExpressons.)
    StreamReader sr = new StreamReader(this.textBox1.Text);
                string strValue = sr.ReadToEnd();
                string[] strSpliter =new string[1];
                strSpliter[0] = "References";
                string[] strSplitValue = strValue.Split(strSpliter, StringSplitOptions.None);
                String[] strParaValue = strSplitValue[1].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                FileStream fst = new FileStream(@"E:\TrueText.txt",FileMode.Append);
                StreamWriter swt = new StreamWriter(fst);
                FileStream fsf = new FileStream(@"E:\FalseText.txt", FileMode.Append);
                StreamWriter swf = new StreamWriter(fsf);
                swt.WriteLine("Startred on :" + DateTime.Now.ToString("yyyy/MM/dd/hh/mm/ss") + "\n");
                swf.WriteLine("Startred on :" + DateTime.Now.ToString("yyyy/MM/dd/hh/mm/ss") + "\n");
                foreach (string strPara in strParaValue)
                {
                    string[] strAuthorsPart = strPara.Split('.');
                    string[] strAuthorslist = strAuthorsPart[0].Split(',');
                    string[] strAuthor = strAuthorslist[0].Split(' ');
                    if (strSplitValue[0].Contains(strAuthor[0].Trim()))
                    {
                        swt.WriteLine(strAuthor[0] + "\t");
                    }
                    else
                    {
                        swf.WriteLine(strAuthor[0] + "\t");
                    }
