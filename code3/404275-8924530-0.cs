      public void MethodeB()
      {
        lock(locker)  // same instance as MethodA is using
        {
          CallToMethodInOtherClass(myList);
        }
      }
