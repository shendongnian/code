    private async Task AddProjectDrawingAndComponentsFromServerToLocalDbAsync(
        CreateDbContext1 db, Project item)
    {
        var drawings = await client.GetDrawingsAsync(item.ProjectId);
        foreach (var draw in drawings)
        {
            // whatever
        }
        db.SaveChanges();
    }
