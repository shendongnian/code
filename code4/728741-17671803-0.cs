     TextBox test = ((TextBox)e.Row.Cells[7].Controls[0]);
                test.ID = "TextBox1";
                test.Attributes.Add('class','TextBox1');
                TextBox test2 = ((TextBox)e.Row.Cells[8].Controls[0]);
                test2.ID = "TextBox2";
                test.Attributes.Add('class','TextBox2');
                test.Attributes.Add("onChange", "javascript:MyFunc(TextBox1, TextBox2);");
