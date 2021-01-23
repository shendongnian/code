    class NPC {
	static bool isBeingControlled = false;
	public void OnUpdate() {
		if (isBeingControlled)
		{
			//set camera position to NPC position (make sure you're using NPC as an instantiated class)
			//accept key input WASD or whatever you are using and move NPC according to input.
		}
	}
