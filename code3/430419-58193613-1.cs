public string pathret()
{
    return textBox.Text;
}
Form 2
class Main
{
    public void someMethod()
    {
        Form1 f1 = new Form1();
        string desiredValue = f1.pathret();
    }
}
