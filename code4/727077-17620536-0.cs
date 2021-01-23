    public interface IPositionable
    {
	 void Move(int x, int y, int z);
    }
    public abstract class Positionable : IPositionable
    {
	 public int x { get; set; }
	 public int y { get; set; }
	 public int z { get; set; }
	
	 public void Move( int x, int y, int z )
	 {
		this.x += x;
		this.y += y;
		this.z += z;
	 }
    }
