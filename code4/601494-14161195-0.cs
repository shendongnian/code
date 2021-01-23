        public int CompareTo(DisplayItemsEntity other)
        {
           if(other.ProjectName.CompareTo(this.ProjectName) != 0)
           {
               return other.ProjectName.CompareTo(this.ProjectName)
           }
           //else do the second comparison and return
           return result;
        }
