    /// <summary>
    /// 
    /// </summary>
    /// <param name="nameEntities"></param>
    /// <param name="childID"></param>
    /// <returns></returns> <!--etc-->
    private delegate Nullable<int> ExtractParentIdDelegate(IEnumerable<int> nameEntities, int childID);
    /// <summary>
    /// 
    /// </summary>
    private ExtractParentIdDelegate FuncExtractParentId
    {
        get
        {
            return this._extractParentId = this._extractParentId ?? new ExtractParentIdDelegate(delegate(IEnumerable<int> nameEntites, int childID)
                                                                        {
                                                                                //
                                                                        });
        }
    }
