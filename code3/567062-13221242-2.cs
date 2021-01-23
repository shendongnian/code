    class myForm : Form{
        public int Result;
        private Label lblText;
        private Button btnOk, btnCancel;
        private CheckBox[] checkboxes;     
    
        public myForm(string text, params string[] choicesText){
            //set up components
            lblText = new Label(){
               Text = text,
               AutoSize = true,
               Location = new Point(10, 10)
               //...
            };
            
            checkboxes = new CheckBox[choicesText.Length];
            int locationY = 30;
            for(int i = 0; i < checkboxes.Length; i++){
               checkboxes[i] = new CheckBox(){
                   Text = choicesText[i],
                   Location = new Point(10, locationY),
                   Name = (i + 1).ToString(),
                   AutoSize = true,
                   Checked = false
                   //...
               };
    
               locationY += 10;
            }
    
            btnOk = new Button(){
               Text = "OK",
               AutoSize = true,
               Location = new Point(20, locationY + 20)
               //...
            };
            btnOk += new EventHandler(btnOk_Click);
            //and so on 
            this.Controls.AddRange(checkboxes);
            this.Controls.AddRange(new Control[]{ lblText, btnOk, btnCancel /*...*/ });
        }
        
        private void btnOk_Click(object sender, EventArgs e){
            Result = checkboxes.Where(x => x.Checked == true).Select(x => Convert.ToInt32(x.Name)).FirstOrDefault();
            this.Close();
        }      
    }
