    public void button1_Click(object sender, EventArgs e)
    { 
        string a = "help";
        File.WriteAllText(@"C:\myfolder\myfile.txt", a); //Change this to your real file location
    }
    public void button2_Click(object sender, EventArgs e)
    {
        string d = File.ReadAllText(@"C:\myfolder\myfile.txt");
        //this is where I need to call the string "a" value from button1_click 
        string b = "I need";
        string c = b + d; //Instead of a, put the variable name (d in this case)          
    }
