    interface IFluentTable
    {
     IFluentTable addTableCellwithCheckbox(string chk, bool isUnchecked, 
                                                            bool  isWithoutLabel)
     IFluentTable addTableCellwithTextbox(string name, bool isEditable)
     //maybe you could add the static factory method New() here also 
    }
