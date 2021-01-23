        public class A<T> {}
        public class B<T> : A<T> {}
        public class C<T> where T: E {}
        public class D<T> : C<T> where T: F {}
        public class E {}
        public class F : E {}
        public class G : F {}
    
        typeof(A<>).IsAssignableFrom(typeof(B<>))              // false
        typeof(A<object>).IsAssignableFrom(typeof(B<object>))  // true
        typeof(A<string>).IsAssignableFrom(typeof(B<string>))  // true
        typeof(C<E>).IsAssignableFrom(typeof(D<F>))            // false
        typeof(C<F>).IsAssignableFrom(typeof(D<F>))            // true
        typeof(C<G>).IsAssignableFrom(typeof(D<G>))            // true
