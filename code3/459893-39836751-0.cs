    enter code here private void button1_Click(object sender, EventArgs e){double myX; if (!double.TryParse(textBox1.Text, out myX)){
                System.Console.WriteLine("it's not a double ");
                return;
            }
            else System.Console.WriteLine("it's a double ");
}
