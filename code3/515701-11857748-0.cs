    view.BeginUpdate();
    try {
        ...view options modifications...
        view.BeginDataUpdate();
        try {
            ...data modifications...
        }
        finally{ view.EndDataUpdate(); } // real data update here
    
        view.BeginSummaryUpdate();
        try {
            ...summary modifications...
        }
        finally{ view.EndSummaryUpdate(); } // real summary recalculation
        ...another view options modifications...
    }
    finally{ view.EndUpdate(); } // real visual update
