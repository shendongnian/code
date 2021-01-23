    namespace wcfMyService
    {
        // this list all derivation for the easy to follow service.
        // this service will have LOTS of function so ability
        // to split in multiple classes was necessary
        // on client side we only see 1 set of function all mixed together
        // but at least working on it it's easy to follow for us since we have a structure
    
        #region Class Derivation
    
        public class CDerivative : CDefaultClass { }
    
        public partial class CDefaultClass : CDefaultClass2 { }  
    
        // NOTE THAT ALL NEW CLASSES MUST :
        // - Be PARTIAL classes
        // - Implement their OWN interface
    
        // new class would be
        // public partial class CDefaultClass2 : CMyNewClass { }
        // and so on. previous class derive from the new class
    
        #endregion
    
        #region Interface Derivation
    
        [ServiceContract]
        public interface IDerivative : IDefaultInterface { }
    
        public partial interface IDefaultInterface : IDefaultInterface2 { }
    
        // NOTE THAT ALL NEW INTERFACE MUST :
        // - Be PARTIAL Interface
        // - Have attribute [ServiceContract]
        // - all methods need [OperationContract] as usual
    
        // new class interface would be
        // public partial interface IDefaultInterface2 : IMyNewClass { }
        // and so on. previous class interface derive from the new class interface
    
        #endregion
    }
