    class Z {
        doSomething(){
            //main logic
            fireEvent("SomethingDone")
        }
    }
    class A {
        A(){
            subscribeToEvent("SomethingDone", onSomethingDone)
        }
        onSomethingDone(){
            //subclass logic
        }
    }
    class B {
        B(){
            subscribeToEvent("SomethingDone", onSomethingDone)
        }
        onSomethingDone(){
            //subclass logic
        }
    }
