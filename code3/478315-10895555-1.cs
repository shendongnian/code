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
    {
        ProxyOperations po;
        // Populate it
        po.addOperation("Op1", "ns1", oper1ObjectNs1);
        po.addOperation("Op1", "ns2", oper1ObjectNs2);
        po.addOperation("Op1", "ns3", oper1ObjectNs3);
        po.addOperation("Op2", "ns1", oper2ObjectNs1);
        po.addOperation("Op2", "ns2", oper2ObjectNs2);
        // now use it
        po.doOperation("Op1", "ns2");
    }
