    public override bool Equals(object obj)
            {
                if(obj is Operand)
                {
                    Operand op = obj as Operand;
                    if (this.opr == op.opr && this.state == op.state)
                        return true;
                }
                return false;
            }
      public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + opr.GetHashCode();
            hash = (hash * 7) + state.GetHashCode();
            return hash;
        }
