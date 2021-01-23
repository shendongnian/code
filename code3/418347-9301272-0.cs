    class SomeClass
    {
        //Fields (Or Properties)
        string a;
    
        public void button1_Click(object sender, EventArgs e)
        { 
            a = "help"; //Or however you assign it
        }
    
        public void button2_Click(object sender, EventArgs e)
        {
            string b = "I need";
            string c = b + (a ?? String.Empty); //'a' should be null checked somehow.
        }
    }
