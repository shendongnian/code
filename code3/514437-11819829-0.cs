        public abstract class PolicyDetailed
        {
            internal abstract DataContainer GetActiveAsset();
        }
        public abstract class PolicyDetailed<T> : PolicyDetailed where T : DataContainer
        {
            internal abstract T GetActiveAssetGeneric();
        
            internal override DataContainer GetActiveAsset()
            {
                return GetActiveAssetGeneric();
            }
        }
        public class PolicyAccident : PolicyDetailed<AccidentContainer>
        {
            internal override AccidentContainer GetActiveAssetGeneric()
            {
                return null;
            }    
        }
