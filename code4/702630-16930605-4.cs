	/// <summary>A simple frame-based game engine.</summary>
	interface IGameEngine
	{
		/// <summary>Proceed to next frame.</summary>
		void NextFrame();
		/// <summary>Await this to schedule action.</summary>
		/// <param name="framesToWait">Number of frames to wait.</param>
		/// <returns>Awaitable task.</returns>
		Task Wait(int framesToWait);
	}
