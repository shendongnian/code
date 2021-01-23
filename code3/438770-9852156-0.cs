	using System;
	using System.Runtime.InteropServices;
	namespace COMHelper
	{
		/// <summary>
		/// Disposable wrapper for COM interface pointers.
		/// </summary>
		/// <typeparam name="T">COM interface type to wrap.</typeparam>
		public class ComPtr<T> : IDisposable
		{
			private object m_oObject;
			private bool m_bDisposeDone = false;
			
			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="oObject"></param>
			public ComPtr ( T oObject )
			{
				if ( oObject == null )
					throw ( new ArgumentNullException ( "Invalid reference for ComPtr (cannot be null)" ) );
				if ( !( Marshal.IsComObject ( oObject ) ) )
					throw ( new ArgumentException ( "Invalid type for ComPtr (must be a COM interface pointer)" ) );
				
				m_oObject = oObject;
			}
			
			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="oObject"></param>
			public ComPtr ( object oObject ) : this ( (T) oObject )
			{
			}
			
			/// <summary>
			/// Destructor
			/// </summary>
			~ComPtr ()
			{
				Dispose ( false );
			}
			
			/// <summary>
			/// Returns the wrapped object.
			/// </summary>
			public T Object
			{
				get
				{
					return ( (T) m_oObject );
				}
			}
			/// <summary>
			/// Implicit cast to type T.
			/// </summary>
			/// <param name="oObject">Object to cast.</param>
			/// <returns>Returns the ComPtr object cast to type T.</returns>
			public static implicit operator T ( ComPtr<T> oObject )
			{
				return ( oObject.Object );
			}
			/// <summary>
			/// Frees up resources.
			/// </summary>
			public void Dispose ()
			{
				Dispose ( true );
				GC.SuppressFinalize ( this );
			}
			
			/// <summary>
			/// Frees up resurces used by the object.
			/// </summary>
			/// <param name="bDispose">When false, the function is called from the destructor.</param>
			protected void Dispose ( bool bDispose )
			{
				try
				{
					if ( !m_bDisposeDone && ( m_oObject != null ) )
					{
						Marshal.ReleaseComObject ( m_oObject );
						m_oObject = null;
					}
				}
				finally
				{
					m_bDisposeDone = true;
				}
			}
		}
	}
