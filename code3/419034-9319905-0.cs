    public class Form1 : Form {
        
        private string[] statuses = { "A", "B", "C", "D", "E" }; // Init with proper values somewhere
        private int index = 0;
     
        private void OnTimerTick(object sender, EventArgs e) {
            string status = statuses[index];
            
            index++;
            if (index == statuses.Length) { // If index = Array.Length means we're 
                                            // outside bounds of array
                index = 0;
            }
        }
    }
