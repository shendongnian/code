      public void MethodeB()
      {
        lock(locker)
        {
          CallToMethodInOtherClass(myList);
        }
      }
