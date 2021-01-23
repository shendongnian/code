public class ProcessEventArgs : EventArgs
{
  public string Name { get; internal set; }
  public int  Age { get; internal set; }
  public ProcessEventArgs(string Name, int Age)
  {
    this.Name = Name;
    this.Age = Age;
  }
}
