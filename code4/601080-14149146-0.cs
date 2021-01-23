    Dictionary<int,int[]> hostileFactions = new Dictionary<int,int[]>(){
        {1,new[]{5}}, {2,new[]{4,5}}
    };
    public void isHostile(int ownF, int oppF) {
        return hostileFactions[ownF].Contains(oppF)
    }
