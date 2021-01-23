     [Serializable]
        public class FormState
        {
            public int RowIndex { get; set; }
            public int ColIndex { get; set; }
            public string BackColor { get; set; }
        }
    
        [Serializable]
        public class Layout : Collection<FormState> { 
        
            public Layout(){}
        }
    
..
            public void SomeCallingMethod() {
                Layout l = new Layout();
                foreach (FormState fs in l) {
                    buttons[fs.RowIndex, fs.ColIndex].BackColor = ColorTranslator.FromHtml(fs.BackColor);
                }     
            }
