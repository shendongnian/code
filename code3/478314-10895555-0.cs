    class ProxyOperations
    {
        addOperation(string opName, string namespace, OperationBase op);
        // You'll have to figure out what to do with the operation parameters,
        // maybe wrap them in a parameter context
        void doOperation(string opName, string namespace) {
            // lookup operation object and execute it
        }
        typedef map<string, OperationsBase> OperMap;
        typedef map<string, operMap> NamespaceMap;
        NamespaceMap namespaceOperationMap_;
    };
