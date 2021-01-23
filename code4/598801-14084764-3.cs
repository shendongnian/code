    public interface IAgentRepository
    {
        IList<Agent> LoadAgents();
        void Save(IEnumerable<Agent> agents);
    }
