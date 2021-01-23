       public override bool IsValid(object value) {
                int[] valueSet = this.Values[0] as int[];
                if (valueSet == null) {
                    throw new Exception("Values must be provided");
                }
                foreach (var v in valueSet) {
                    if (object.Equals(v, value)) {
                        return true;
                    }
                }
    
                return false;
            }
