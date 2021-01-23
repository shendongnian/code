            XDocument map = XDocument.Parse("<Exam> " +
              "<Question number= \"1\" Text=\"What is IL Code\">" +
               " <Answer Text=\"Half compiled, Partially compiled code\"> </Answer>" +
              "</Question>" +
              "<Question number=\"2\" Text=\"What is JIT\">" +
              "  <Answer Text=\"IL code to machine language\"> </Answer>" +
              "</Question>" +
              "<Question number=\"3\" Text=\"What is CLR\">" +
              "  <Answer Text=\"Heart of the engine , GC , compilation , CAS(Code access security) , CV ( Code verification)\"> </Answer>" +
              "</Question>" +
            "</Exam>");
            var QuestionList = map.Descendants("Question").ToList();
            foreach (XElement nodexm in QuestionList)
            {
                if((string)nodexm.Attributes("Text").First()== label2.Text)
                {
                    string[] arrUserAnswer = textBox1.Text.Trim().ToLower().Split(' ');
                    string[] arrXMLAnswer = ((string)nodexm).Trim().ToLower().Split(' ');
                    List<string> lststr1 = new List<string>();
                    foreach (string nextStr in arrXMLAnswer)
                    {
                        if (Array.IndexOf(arrUserAnswer, nextStr) != -1)
                        {
                            lststr1.Add(nextStr);
                        }
                    }
                    if (lststr1.Count > 0)
                    {
                        label4.Visible = true;
                        label4.Text = "Your Answer is "+ ((100 * lststr1.Count) / arrXMLAnswer.Length).ToString() + "%" + "Correct";
                    }
                    else
                    {
                        label4.Text = "Your Answer is Wrong";
                    }
                }
            }
