    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    //
    namespace Benchmarking {
    	//
    	static class Collections {
    		//
    		public static void Main() {
    			const int limit = 9000000;
    			Stopwatch sw = new Stopwatch();
    			Stack<int> stack = new Stack<int>();
    			Queue<int> queue = new Queue<int>();
    			List<int> list1 = new List<int>();
    			List<int> list2 = new List<int>();
    			LinkedList<int> linkedlist1 = new LinkedList<int>();
    			LinkedList<int> linkedlist2 = new LinkedList<int>();
    			int dummy;
    
    			sw.Reset();
    			Console.Write( "{0,40}  ", "stack.Push");
    			sw.Start();
    			for ( int i = 0; i < limit; i++ ) {
    				stack.Push( i );
    			}
    			sw.Stop();
    			Console.WriteLine( sw.ElapsedMilliseconds.ToString() );
    			sw.Reset();
    			Console.Write( "{0,40}  ", "stack.Pop" );
    			sw.Start();
    			for ( int i = 0; i < limit; i++ ) {
    				stack.Pop();
    			}
    			sw.Stop();
    			Console.WriteLine( sw.ElapsedMilliseconds.ToString() );
    
    
    			sw.Reset();
    			Console.Write( "{0,40}  ", "queue.Enqueue" );
    			sw.Start();
    			for ( int i = 0; i < limit; i++ ) {
    				queue.Enqueue( i );
    			}
    			sw.Stop();
    			Console.WriteLine( sw.ElapsedMilliseconds.ToString() );
    			sw.Reset();
    			Console.Write( "{0,40}  ", "queue.Dequeue" );
    			sw.Start();
    			for ( int i = 0; i < limit; i++ ) {
    				queue.Dequeue();
    			}
    			sw.Stop();
    			Console.WriteLine( sw.ElapsedMilliseconds.ToString() );
    
    			//sw.Reset();
    			//Console.Write( "{0,40}  ", "Insert to List at the front..." );
    			//sw.Start();
    			//for ( int i = 0; i < limit; i++ ) {
    			//	list1.Insert( 0, i );
    			//}
    			//sw.Stop();
    			//Console.WriteLine( sw.ElapsedMilliseconds.ToString() );
    			//
    			//sw.Reset();
    			//Console.Write( "{0,40}  ", "RemoveAt from List at the front..." );
    			//sw.Start();
    			//for ( int i = 0; i < limit; i++ ) {
    			//	dummy = list1[ 0 ];
    			//	list1.RemoveAt( 0 );
    			//	dummy++;
    			//}
    			//sw.Stop();
    			//Console.WriteLine( sw.ElapsedMilliseconds.ToString() );
    
    			sw.Reset();
    			Console.Write( "{0,40}  ", "list2.Add" );
    			sw.Start();
    			for ( int i = 0; i < limit; i++ ) {
    				list2.Add( i );
    			}
    			sw.Stop();
    			Console.WriteLine( sw.ElapsedMilliseconds.ToString() );
    			sw.Reset();
    			Console.Write( "{0,40}  ", "list2.RemoveAt" );
    			sw.Start();
    			for ( int i = 0; i < limit; i++ ) {
    				list2.RemoveAt( list2.Count - 1 );
    			}
    			sw.Stop();
    			Console.WriteLine( sw.ElapsedMilliseconds.ToString() );
    
    
    			sw.Reset();
    			Console.Write( "{0,40}  ", "linkedlist1.AddFirst" );
    			sw.Start();
    			for ( int i = 0; i < limit; i++ ) {
    				linkedlist1.AddFirst( i );
    			}
    			sw.Stop();
    			Console.WriteLine( sw.ElapsedMilliseconds.ToString() );
    			sw.Reset();
    			Console.Write( "{0,40}  ", "linkedlist1.RemoveFirst" );
    			sw.Start();
    			for ( int i = 0; i < limit; i++ ) {
    				linkedlist1.RemoveFirst();
    			}
    			sw.Stop();
    			Console.WriteLine( sw.ElapsedMilliseconds.ToString() );
    
    
    			sw.Reset();
    			Console.Write( "{0,40}  ", "linkedlist2.AddLast" );
    			sw.Start();
    			for ( int i = 0; i < limit; i++ ) {
    				linkedlist2.AddLast( i );
    			}
    			sw.Stop();
    			Console.WriteLine( sw.ElapsedMilliseconds.ToString() );
    			sw.Reset();
    			Console.Write( "{0,40}  ", "linkedlist2.RemoveLast" );
    			sw.Start();
    			for ( int i = 0; i < limit; i++ ) {
    				linkedlist2.RemoveLast();
    			}
    			sw.Stop();
    			Console.WriteLine( sw.ElapsedMilliseconds.ToString() );
    
    
    			// Fill again
    			for ( int i = 0; i < limit; i++ ) {
    				list2.Add( i );
    			}
    			sw.Reset();
    			Console.Write( "{0,40}  ", "list2[i]" );
    			sw.Start();
    			for ( int i = 0; i < limit; i++ ) {
    				dummy = list2[ i ];
    			}
    			sw.Stop();
    			Console.WriteLine( sw.ElapsedMilliseconds.ToString() );
    
    
    			// Fill array
    			sw.Reset();
    			Console.Write( "{0,40}  ", "FillArray" );
    			sw.Start();
    			var array = new int[ limit ];
    			for ( int i = 0; i < limit; i++ ) {
    				array[ i ] = i;
    			}
    			sw.Stop();
    			Console.WriteLine( sw.ElapsedMilliseconds.ToString() );
    
    			sw.Reset();
    			Console.Write( "{0,40}  ", "array[i]" );
    			sw.Start();
    			for ( int i = 0; i < limit; i++ ) {
    				dummy = array[ i ];
    			}
    			sw.Stop();
    			Console.WriteLine( sw.ElapsedMilliseconds.ToString() );
    
    
    			// Fill again
    			for ( int i = 0; i < limit; i++ ) {
    				linkedlist1.AddFirst( i );
    			}
    			sw.Reset();
    			Console.Write( "{0,40}  ", "foreach_linkedlist1" );
    			sw.Start();
    			foreach ( var item in linkedlist1 ) {
    				dummy = item;
    			}
    			sw.Stop();
    			Console.WriteLine( sw.ElapsedMilliseconds.ToString() );
    
    			//
    			Console.WriteLine( "Press Enter to end." );
    			Console.ReadLine();
    		}
    	}
    }
