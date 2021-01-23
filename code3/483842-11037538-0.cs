    /// <summary>
    /// Iterates the (potentially) nested masterpage structure, looking for the specified type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="currentMaster">The current master.</param>
    /// <returns>Masterpage cast to specified type or null if not found.</returns>
    public static T GetMasterPageOfType<T>(MasterPage currentMaster) where T : MasterPage
    {
        T typedRtn = null;
        while (currentMaster != null)
        {
            typedRtn = currentMaster as T;
            if (typedRtn != null)
            {
                return typedRtn; //End here
            }
            currentMaster = currentMaster.Master; //One level up for next iteration
        }
        return null;
    }
