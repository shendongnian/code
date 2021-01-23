    class Stack<T>{
       int i;
       T[] array = new T[1000];
       public void Push(T element){
           array[i++] = element;
       }
    }
    
    class BaseClass{
    }
    
    class SubClass : BaseClass{
    }
