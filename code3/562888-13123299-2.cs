    class DrawManager
    {
    public:
        DrawManager() {}
        ~DrawManager()
        {
            for ( ActionList::iterator i = actions.begin(), e = actions.end(); i != e; i++ )
            {
                delete *i;
            }
            actions.clear();
        }
        
        void draw()
        {
            for ( ActionList::iterator i = actions.begin(), e = actions.end(); i != e; i++ )
            {
                (*i)->execute();
            }
        }
        
        void addAction(Action* action)
        {
            actions.insert(action);
        }
        
        void removeOwnedActions(void * owner)
        {
            for ( ActionList::iterator i = actions.begin(), e = actions.end(); i != e; i++)
            {
                if ( (*i)->ownerIs(owner) )
                {
                    delete *i;
                    actions.erase(i);
                }
            }
        }
        
    private:
        typedef std::set<Action*,Action::PrioritySorter> ActionList;
        ActionList actions;
    };
