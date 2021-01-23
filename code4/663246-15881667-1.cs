    public struct DFS_TARGET_PRIORITY {
        public DFS_TARGET_PRIORITY_CLASS TargetPriorityClass;
        public UInt16 TargetPriorityRank;
        public UInt16 Reserved;
    }
    public enum DFS_TARGET_PRIORITY_CLASS {
        DfsInvalidPriorityClass = -1,
        DfsSiteCostNormalPriorityClass = 0,
        DfsGlobalHighPriorityClass = 1,
        DfsSiteCostHighPriorityClass = 2,
        DfsSiteCostLowPriorityClass = 3,
        DfsGlobalLowPriorityClass = 4
    }
