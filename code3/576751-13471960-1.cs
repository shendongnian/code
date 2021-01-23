        public bool AnyPreviousReportByGroup(int groupID)
        {
            var item = this;
            do
            {
                if (item.GroupId == groupID)
                {
                    return true;
                }
                item = item.PreviousReport;
            } while (item != null);
            return false;
        }
        public bool AnyNextReportByGroup(int groupID)
        {
            var item = this;
            do
            {
                if (item.GroupId == groupID)
                {
                    return true;
                }
                item = item.NextReport;
            } while (item != null);
            return false;
        }
