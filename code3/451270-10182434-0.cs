    partial void OpenPositions_Compute(ref int result)
    {
        result = this.DataWorkspace.ApplicationData.Positions
            .Count(p => p.IsPositionOpen && position.Client.Id == this.Id);
    }
