        public class DataContainer {}
        public class AccidentContainer : DataContainer{}
        
        public abstract class PolicyDetailed
        {
            internal abstract DataContainer GetActiveAsset();
        }
        
        // This only exists to satisfy the base class abstract member,
        // but at the same time allowing PolicyDetailed<T> to introduce
        // a new member with the same name.
        public abstract class PolicyDetailedBridge<T> : PolicyDetailed
            where T : DataContainer
        {
            protected abstract T GetActiveAssetGeneric();
            
            internal override DataContainer GetActiveAsset()
            {
                return GetActiveAssetGeneric();
            }
        }
        
        public abstract class PolicyDetailed<T> : PolicyDetailedBridge<T>
            where T : DataContainer
        {
            protected sealed override T GetActiveAssetGeneric()
            {
                // Call the *new* abstract method. Eek!
                return GetActiveAsset();
            }
            
            internal abstract new T GetActiveAsset();
        }
        
        public class PolicyAccident : PolicyDetailed<AccidentContainer>
        {
            internal override AccidentContainer GetActiveAsset()
            {
                return null;
            }            
        }
