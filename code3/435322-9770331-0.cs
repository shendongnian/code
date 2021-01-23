    if (Physics.Raycast(mousePositionInWorld, transform.forward, 10)) {
       doSomething ();
    }
    void OnTriggerEnter(Collider other) {
       doSomething ();
    }
    
    void doSomething () {
    }
