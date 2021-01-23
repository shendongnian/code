    public class MyVsHierarchyEvents : IVsHierarchyEvents
    {
       public int OnItemAdded( uint itemidParent, uint itemidSiblingPrev, uint itemidAdded )
       {
          object itemAddedExtObject;
          if ( m_hierarchy.GetProperty( itemidAdded, (int)__VSHPROPID.VSHPROPID_ExtObject, out itemAddedExtObject ) == VSConstants.S_OK )
          {
             var projectItem = itemAddedExtObject as ProjectItem;
             if ( projectItem != null )
             {
                // do something here ...
             }
          }
          return VSConstants.S_OK;
       }
       public int OnItemDeleted( uint itemid )
       {
          object itemExtObject;
          if ( m_hierarchy.GetProperty( itemid, (int)__VSHPROPID.VSHPROPID_ExtObject, out itemExtObject ) == VSConstants.S_OK )
          {
             var projectItem = itemExtObject as ProjectItem;
             if (projectItem != null)
              {
                 // do something here ...
              }
          }
          return ret;
       }
       // handle other events ...
    }
    public class MySolutionEvents : IVsSolutionEvents
    {
       IVsHierarchyEvents m_myVsHierarchyEvents;
       uint m_cookie;
       public int OnAfterOpenProject( IVsHierarchy pHierarchy, int fAdded )
       {
           m_myVsHierarchyEvents = new MyVsHierarchyEvents();
           pHierarchy.AdviseHierarchyEvents( m_myVsHierarchyEvents, out m_cookie );
           // do other things here ...
           return VSConstants.S_OK;
       }
       // handle other events ...
    }
    public class MyPackage : Package
    {
       IVsSolutionEvents m_vsSolutionEvents;
       IVsSolution m_vsSolution;
       uint m_SolutionEventsCookie;
       protected override void Initialize()
       {
          m_vsSolutionEvents = new MySolutionEvents();
          m_vsSolution = GetService( typeof( SVsSolution ) ) as IVsSolution;
          m_vsSolution.AdviseSolutionEvents( m_vsSolutionEvents, out m_SolutionEventsCookie );
       }
    }
