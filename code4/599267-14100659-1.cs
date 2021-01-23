        List<TextBox> inputTextBoxes =  new List<TextBox>();
        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxInput.Text))
            {
                //Get the number of input text boxes to generate
                int inputNumber = Int32.Parse(textBoxInput.Text);
                if (inputTextBoxes != null && inputTextBoxes.Count > inputNumber)
                {
                    int removecount = inputTextBoxes.Count - inputNumber;
                    for (int i = 0; i < removecount; i++)
                    {
                        TextBox t = inputTextBoxes[inputTextBoxes.Count-1];
                        inputTextBoxes.RemoveAt(inputTextBoxes.Count - 1);
                        t.Dispose();
                    }
                    return;
                }                
                //Generate labels and text boxes
                for (int i = 1; i <= inputNumber; i++)
                {
                    //Create a new label and text box
                    Label labelInput = new Label();
                    TextBox textBoxNewInput = new TextBox();
                    //Initialize label's property
                    labelInput.Text = "Product" + i;
                    labelInput.Location = new Point(30, textBoxInput.Bottom + (i * 30));
                    labelInput.AutoSize = true;
                    //Initialize textBoxes Property
                    textBoxNewInput.Location = new Point(labelInput.Width, labelInput.Top - 3);
                    //Add the newly created text box to the list of input text boxes
                    inputTextBoxes.Add(textBoxNewInput);
                    //Add the labels and text box to the form
                    this.Controls.Add(labelInput);
                    this.Controls.Add(textBoxNewInput);
                }
            } 
        }
