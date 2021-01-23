    // If we didn't have properties, this is what the two first lines would be. Ick!
    private int assignedCount;
    private int unassignedCount;
 
    public int GetAssignedCount()
    {
        return assignedCount;
    }
    public void SetAssignedCount(int value)
    {
        assignedCount = value;
    }
    public int GetUnassignedCount()
    {
        return unassignedCount;
    }
    public void SetUnassignedCount(int value)
    {
        unssignedCount = value;
    }
    // And here's the read-only TotalCount property translation
    public int GetTotalCount()
    {
        return GetUnassignedCount() + GetTotalCount();
    }
