    StreamReader sr = new StreamReader("test.txt");
                string s;
                string resultText = "";
                while ((s = sr.ReadLine()) != null)
                {
                    string text = s;
                    string[] splitedText = text.Split('\t');
                    for (int i = 0; i < splitedText.Length; i++)
                    {
                        if (splitedText[i] == "")
                        {
                            resultText += "0 \t";
                        }
                        else
                        {
                            resultText += splitedText[i] + " \t";
                        }
                    }
                    resultText += "\n";
                }
                Console.WriteLine(resultText);
