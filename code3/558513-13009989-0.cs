    void FixedUpdate () {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            StartCoroutine(TweenCoroutine());
        }
    }
    
    IEnumerator TweenCoroutine() {
        // To point 1
        Hashtable props = new Hashtable();
        props.Add("position", new Vector3(756f,112f,1124f));
        props.Add("physics", true);
        // Start first tween and wait for it to finish
        yield return Ani.Mate.To(transform, 2, props);  
        // To point 2
        Hashtable props2 = new Hashtable();
        props2.Add("position", new Vector3(731f,112f,1124f));
        props2.Add("physics", true);
        // Start second tween and wait for it to finish
        yield return Ani.Mate.To(transform, 2, props2);
        
        // etc...
    }
