    class Form2 {
        public static bool IsOpen { get;set; }
        public Form2() {
            Load += (sender, e) => { Form2.IsOpen = true; };
            Closed += (sender, e) => { Form2.IsOpen = false; };
        }
    }
