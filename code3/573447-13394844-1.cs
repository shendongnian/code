    public Route(Route route, Position nextPosition)
    {
      this.startPosition = route.startPosition;
      foreach (Position position in route.nodes)
      {
        this.nodes.Add(position);
      }
      this.Add(nextPosition);
      this.findConnection();
    }
