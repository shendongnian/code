    class MyType { 
      public void Draw() {
        ...
      }
    }
    
    for (int i = 0; i < arrayList.Count; i++) {
      MyType current = (MyType)arrayList[i];
      current.Draw();
    }
