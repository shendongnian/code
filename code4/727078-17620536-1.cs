    public class PositionMediator
    {
	 public List<IPositionable> Group { get; set; }
	 public PositionMediator()
	 {
		Group = new List<IPositionable>();
		Group.Add(new Rectangle());
		Group.Add(new Triangle());
		Group.Add(new Square());
	 }
	 public void MoveGroup( int x, int y, int z )
	 {
		foreach( var pos in Group )
		{
			pos.Move(x,y,z);
		}
	 }
    }
