    private async void PanelBoard_MouseCtlClick(object sender, HexEventArgs e) {
      GoalHex = e.Coords;
      // other processing to prepare.
      try { Path = await MapBoard.GetDirectedPathAsync(MapBoard[StartHex], MapBoard[GoalHex]); } 
      catch (OperationCanceledException) { Path = default(IDirectedPath); }
    }
    public static async Task<IDirectedPath> GetDirectedPathAsync(
      this IBoard<IHex> @this, 
      IHex start,  IHex goal
    ) {
      if (@this == null) throw new ArgumentNullException("this");
      return @this.GetDirectedPath(start, goal);
    }
    
    IDirectedPath Path {
      set { /* code here to refresh display when Path is ready */ }
    }
    public static Task<IDirectedPath> GetDirectedPathAsync(
      this IBoard<IHex> @this, 
      IHex start,  IHex goal
    ) {
      if (@this == null) throw new ArgumentNullException("this");
      return Task.Run<IDirectedPath>(
          () => @this.GetDirectedPath(start, goal)
      );
    }
