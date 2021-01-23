    // we have not defined which argument is the "parent" and which is the "child"
    public bool IsTableRelated(DataTable thisOne, DataTable thatOne) {
    
        bool thisToThat = DiveDive(thisOne.Constraints, thatOne);
        bool thatToThis = DiveDive(thatOne.Constraints, thisOne);
    
        return thisToThat || thatToThis;
    }
    public bool DiveDive(ConstraintsCollection constraints, DataTable target) {
        bool theyRelate = false;
    
        foreach (Constraint aConstraint in constraints){
        
            if (aConstraint is ForeignKeyConstraint) {
                if(aConstraint.Table.TableName == target.TableName) {
                    theyRelate = true;
                    break;  // quit while we're ahead.
                }else{
                   theyRelate = DiveDive(aConstraint.Table.Constraints, target);
                }
            } 
        }
    
        return theyRelate;
    }
