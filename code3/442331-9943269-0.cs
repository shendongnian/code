private void button1_Click(object sender, EventArgs e)
   
{
new Thread(new ThreadStart(delegate()
{
AllocConsole();
for (uint i = 0; i < 1000000; ++i)
{
Console.WriteLine("Hello " + i);
}
 
        FreeConsole();
    })).Start();
}
